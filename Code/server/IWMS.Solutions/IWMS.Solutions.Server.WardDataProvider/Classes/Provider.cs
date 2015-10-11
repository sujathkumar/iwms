using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.WardDataProvider.Models;

namespace IWMS.Solutions.Server.WardDataProvider
{
    public class Provider
    {
        #region Members
        private DataAccessDataContext context = null;

        private const string DEFAULT_WARD = "Ward not mapped!";
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new DataAccessDataContext();
            }
        }
        #endregion

        /// <summary>
        /// Retrieve Zone details
        /// </summary>
        public Zone RetrieveZone(int zoneNumber)
        {
            var zone = context.Zones.Where(@w => @w.Number.Equals(zoneNumber)).Select(@s => @s);

            if (zone != null)
            {
                return zone.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Retrieve Ward details
        /// </summary>
        public Ward RetrieveWard(int wardNumber)
        {
            var ward = context.Wards.Where(@w => @w.Number.Equals(wardNumber)).Select(@s => @s);

            if (ward != null)
            {
                return ward.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Retrieve Ward based on the Locality Name
        /// </summary>
        /// <param name="localityName"></param>
        /// <returns></returns>
        public string RetrieveWard(string localityName)
        {
            string wardName = DEFAULT_WARD;
            var wards = context.Localities.Where(@w => @w.Name.Contains(localityName));

            StringBuilder sb = new StringBuilder();

            if (wards.Count() > 1)
            {
                foreach (var ward in wards)
                {
                    sb.AppendLine(context.Wards.Where(@w => @w.Id == ward.WardId).First().Name);
                }

                wardName = sb.ToString();
            }
            else if (wards.Count() == 1)
            {
                wardName = context.Wards.Where(@w => @w.Id == wards.First().WardId).First().Name;
            }

            return wardName;
        }

        /// <summary>
        /// Retrieve Localities
        /// </summary>
        /// <param name="localityName"></param>
        /// <returns></returns>
        public IList<Locality> RetrieveLocalities(string localityName)
        {
            return context.Localities.Where(@w => @w.Name.Trim().StartsWith(localityName)).ToList();
        }

        /// <summary>
        /// Retrieve Ward details
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitide"></param>
        public string RetrieveWard(string latitude, string longitide)
        {
            var latWards = GetWards(Convert.ToDecimal(latitude));
            if (latWards.Count == 0)
            {
                return "NA";
            }

            var longWards = GetWards(latWards, Convert.ToDecimal(longitide));

            if (longWards.Count == 0)
            {
                return "NA";
            }
            else if (longWards.Count > 1)
            {
                //Draw line from longitude
                var cordinates = DrawLineTowardsRight(longWards, Convert.ToDecimal(latitude), Convert.ToDecimal(longitide));

                //Get nearest longitude
                string nearestLatitude = cordinates.OrderBy(@orderby => @orderby.Longitude).First().Latitude;
                string nearestLongitude = cordinates.OrderBy(@orderby => @orderby.Longitude).First().Longitude;
                var nearCordinates = cordinates.Where(@w => @w.Longitude == nearestLongitude).Distinct();

                //Draw line from longitude
                IList<Ward> wards = new List<Ward>();
                foreach (var cordinate in nearCordinates)
                {
                    var cordinateWard = longWards.Where(@w => @w.Id == cordinate.WardId).First();
                    wards.Add(cordinateWard);
                }

                Dictionary<string, int> wardDic = new Dictionary<string, int>();
                foreach (var ward in wards)
                {
                    int count = 0;
                    bool cordinatesBottom = DrawLineTowardsBottom(ward, Convert.ToDecimal(latitude), Convert.ToDecimal(longitide));
                    if (cordinatesBottom)
                    {
                        count++;
                    }
                    bool cordinatesLeft = DrawLineTowardsLeft(ward, Convert.ToDecimal(latitude), Convert.ToDecimal(longitide));
                    if (cordinatesLeft)
                    {
                        count++;
                    }
                    bool cordinatesTop = DrawLineTowardsTop(ward, Convert.ToDecimal(latitude), Convert.ToDecimal(longitide));
                    if (cordinatesTop)
                    {
                        count++;
                    }

                    if (!wardDic.ContainsKey(ward.Name))
                    {
                        wardDic.Add(ward.Name, count);
                    }
                }

                //Get ward based on near Cordinate Increamenting by a certain longitude
                var wardsFinal = wardDic.OrderByDescending(@orderby => @orderby.Value);
                int rank = wardDic.OrderByDescending(@orderby => @orderby.Value).First().Value;

                if (wardsFinal.Where(@w => @w.Value == rank).Count() > 1)
                {
                    decimal counter = 0.00005M;
                    string wardName = RetrieveWard(nearestLatitude, Decimal.Add(Convert.ToDecimal(nearestLongitude), counter).ToString());
                    wardDic.Remove(wardName);
                }

                return wardDic.OrderByDescending(@orderby => @orderby.Value).First().Key.ToString();
            }

            return longWards.FirstOrDefault().Name;
        }

        /// <summary>
        /// InsertWardDetails
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="wardNumber"></param>
        /// <param name="wardName"></param>
        /// <param name="cordinatePath"></param>
        public void InsertWard(Guid zoneId, int wardNumber, string wardName, string cordinatePath)
        {
            IList<CordinatePoint> cordinates = ReadCordinates(cordinatePath);
            CordinatePoint top, left, bottom, right = null;

            ObtainCordinatePoints(cordinates, out top, out left, out bottom, out right);

            var wardId = InsertWardMetadata(zoneId, wardNumber, wardName, top, left, bottom, right, context);

            InsertCordinateMetadata(wardId, cordinates, context);
        }

        /// <summary>
        /// InsertWardDetails for Locality
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="wardNumber"></param>
        /// <param name="wardName"></param>
        /// <param name="localityPath"></param>
        public void InsertWard(string localityPath)
        {
            IList<LocalityPoint> localities = ReadLocality(localityPath);

            IList<Locality> localityList = new List<Locality>();

            foreach (var locality in localities)
            {
                var wards = context.Wards.Where(@w => @w.Number == locality.WardNumber);
                Guid wardId;

                if (wards.Count() > 1)
                {
                    wardId = wards.Where(@w => @w.Name.Contains(locality.SubWardNumber.ToString())).First().Id;
                }
                else
                {
                    wardId = wards.First().Id;
                }

                Locality loc = new Locality
                {
                    Id = Guid.NewGuid(),
                    Name = locality.DisplayName,
                    WardId = wardId
                };

                localityList.Add(loc);
            }

            context.Localities.InsertAllOnSubmit(localityList.AsEnumerable());
            SubmitData();
        }

        private void InsertCordinateMetadata(Guid wardId, IList<CordinatePoint> cordinates, DataAccessDataContext context)
        {
            IList<Cordinate> cordinateList = new List<Cordinate>();

            foreach (var cordinate in cordinates)
            {
                Cordinate cordinatePoint = new Cordinate
                {
                    Id = Guid.NewGuid(),
                    Latitude = cordinate.Latitude,
                    Longitude = cordinate.Longitude,
                    WardId = wardId,
                    Rank = cordinate.Rank
                };

                cordinateList.Add(cordinatePoint);
            }

            context.Cordinates.InsertAllOnSubmit(cordinateList.AsEnumerable());
            SubmitData();
        }

        private Guid InsertWardMetadata(Guid zoneId, int wardNumber, string wardName, CordinatePoint top, CordinatePoint left, CordinatePoint bottom, CordinatePoint right, DataAccessDataContext context)
        {
            Guid wardId = Guid.NewGuid();

            Ward ward = new Ward
            {
                Id = wardId,
                Number = wardNumber,
                Name = wardName,
                ZoneId = zoneId,
                TopCordinate = top.Latitude + "," + top.Longitude,
                LeftCordinate = left.Latitude + "," + left.Longitude,
                BottomCordinate = bottom.Latitude + "," + bottom.Longitude,
                RightCordinate = right.Latitude + "," + right.Longitude
            };

            context.Wards.InsertOnSubmit(ward);
            SubmitData();

            return wardId;
        }

        /// <summary>
        /// ReadCordinates
        /// </summary>
        private IList<CordinatePoint> ReadCordinates(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            IList<CordinatePoint> cordinates = new List<CordinatePoint>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');

                if (!values[0].ToString().Contains("Rank") && !string.IsNullOrEmpty(values[0]))
                {
                    cordinates.Add(new CordinatePoint { Rank = Convert.ToInt32(values[0]), Latitude = values[1], Longitude = values[2] });
                }
            }

            return cordinates;
        }

        /// <summary>
        /// ReadCordinates
        /// </summary>
        private IList<LocalityPoint> ReadLocality(string path)
        {
            var reader = new StreamReader(File.OpenRead(path));
            IList<LocalityPoint> localityList = new List<LocalityPoint>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                string subWard = string.Empty;

                if (values.Length > 1)
                {
                    if (string.IsNullOrEmpty(values[1]))
                    {
                        subWard = "0";
                    }
                    else
                    {
                        subWard = values[1];
                    }

                    if (!values[0].ToString().Contains("Ward No") && !string.IsNullOrEmpty(values[0]))
                    {
                        for (int i = 2; i < values.Length; i++)
                        {
                            localityList.Add(new LocalityPoint { DisplayName = values[i].Replace("\"", ""), SubWardNumber = Convert.ToInt32(subWard), WardNumber = Convert.ToInt32(values[0]) });
                        }
                    }
                }
            }

            return localityList;
        }

        /// <summary>
        /// Obtain CordinatePoints
        /// </summary>
        /// <param name="corDic"></param>
        private void ObtainCordinatePoints(IList<CordinatePoint> cordinates, out CordinatePoint top, out CordinatePoint left, out CordinatePoint bottom, out CordinatePoint right)
        {
            top = new CordinatePoint();
            left = new CordinatePoint();
            bottom = new CordinatePoint();
            right = new CordinatePoint();

            if (cordinates.Count > 0)
            {
                var topList = cordinates.OrderByDescending(@orderby => @orderby.Latitude).First();
                top = cordinates.Where(@w => @w.Latitude.Equals(topList.Latitude)).OrderBy(@orderby => @orderby.Longitude).First();

                var leftList = cordinates.OrderBy(@orderby => @orderby.Longitude).First();
                left = cordinates.Where(@w => @w.Longitude.Equals(leftList.Longitude)).OrderBy(@orderby => @orderby.Latitude).First();

                var bottomList = cordinates.OrderBy(@orderby => @orderby.Latitude).First();
                bottom = cordinates.Where(@w => @w.Latitude.Equals(bottomList.Latitude)).OrderBy(@orderby => @orderby.Longitude).First();

                var rightList = cordinates.OrderByDescending(@orderby => @orderby.Longitude).First();
                right = cordinates.Where(@w => @w.Longitude.Equals(rightList.Longitude)).OrderBy(@orderby => @orderby.Latitude).First();
            }
        }

        /// <summary>
        /// Draw Line for merging cordinates
        /// </summary>
        /// <param name="ward"></param>
        /// <param name="p"></param>
        private IList<Cordinate> DrawLineTowardsRight(IList<Ward> wards, decimal latitude, decimal longitude)
        {
            decimal counter = 0.00001M;
            IList<Cordinate> cordinates = new List<Cordinate>();
            IList<Cordinate> cordinateList = new List<Cordinate>();

            foreach (var ward in wards)
            {
                cordinateList = cordinateList.Union(context.Cordinates.Where(@w => @w.WardId == ward.Id)).ToList();
            }

            //Get points with equal latitude
            var processedList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == latitude &&
                Convert.ToDecimal(@w.Longitude) > longitude);

            for (int i = 0; i <= 5; i++)
            {
                decimal upLatitude = Decimal.Add(latitude, counter);
                var processedUpList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == upLatitude &&
                    Convert.ToDecimal(@w.Longitude) > longitude);

                decimal downLatitude = Decimal.Subtract(latitude, counter);
                var processedDownList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == downLatitude &&
                    Convert.ToDecimal(@w.Longitude) > longitude);

                cordinates = cordinates.Union(processedList).Union(processedUpList).Union(processedDownList).ToList();
                latitude = Decimal.Add(latitude, counter);
            }

            return cordinates;
        }

        /// <summary>
        /// Draw Line for merging cordinates
        /// </summary>
        /// <param name="ward"></param>
        /// <param name="p"></param>
        private bool DrawLineTowardsBottom(Ward wardDetails, decimal latitude, decimal longitude)
        {
            decimal counter = 0.00001M;
            IList<Cordinate> cordinates = new List<Cordinate>();
            IList<Cordinate> cordinateList = new List<Cordinate>();

            cordinateList = context.Cordinates.Where(@w => @w.WardId == wardDetails.Id).ToList();

            //Get points with equal latitude
            var processedList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == longitude &&
                Convert.ToDecimal(@w.Latitude) < latitude);

            if (processedList.Count() > 0)
            {
                return true;
            }

            for (int i = 0; i <= 5; i++)
            {
                decimal leftLongitude = Decimal.Add(longitude, counter);
                var processedLeftList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == leftLongitude &&
                    Convert.ToDecimal(@w.Latitude) < latitude);

                decimal rightLatitude = Decimal.Subtract(longitude, counter);
                var processedRightList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == rightLatitude &&
                    Convert.ToDecimal(@w.Latitude) < latitude);

                cordinates = cordinates.Union(processedList).Union(processedLeftList).Union(processedRightList).ToList();

                if (cordinates.Count() > 0)
                {
                    return true;
                }

                longitude = Decimal.Add(longitude, counter);
            }

            return false;
        }

        /// <summary>
        /// Draw Line for merging cordinates
        /// </summary>
        /// <param name="ward"></param>
        /// <param name="p"></param>
        private bool DrawLineTowardsLeft(Ward wardDetails, decimal latitude, decimal longitude)
        {
            decimal counter = 0.00001M;
            IList<Cordinate> cordinates = new List<Cordinate>();
            IList<Cordinate> cordinateList = new List<Cordinate>();

            cordinateList = context.Cordinates.Where(@w => @w.WardId == wardDetails.Id).ToList();

            //Get points with equal latitude
            var processedList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == latitude &&
                Convert.ToDecimal(@w.Longitude) < longitude);

            if (processedList.Count() > 0)
            {
                return true;
            }

            for (int i = 0; i <= 5; i++)
            {
                decimal upLatitude = Decimal.Add(latitude, counter);
                var processedUpList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == upLatitude &&
                    Convert.ToDecimal(@w.Longitude) < longitude);

                decimal downLatitude = Decimal.Subtract(latitude, counter);
                var processedDownList = cordinateList.Where(@w => Convert.ToDecimal(@w.Latitude) == downLatitude &&
                    Convert.ToDecimal(@w.Longitude) < longitude);

                cordinates = cordinates.Union(processedList).Union(processedUpList).Union(processedDownList).ToList();

                if (cordinates.Count() > 0)
                {
                    return true;
                }

                latitude = Decimal.Add(latitude, counter);
            }

            return false;
        }

        /// <summary>
        /// Draw Line for merging cordinates
        /// </summary>
        /// <param name="ward"></param>
        /// <param name="p"></param>
        private bool DrawLineTowardsTop(Ward wardDetails, decimal latitude, decimal longitude)
        {
            decimal counter = 0.00001M;
            IList<Cordinate> cordinates = new List<Cordinate>();
            IList<Cordinate> cordinateList = new List<Cordinate>();

            cordinateList = context.Cordinates.Where(@w => @w.WardId == wardDetails.Id).ToList();

            //Get points with equal latitude
            var processedList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == longitude &&
                Convert.ToDecimal(@w.Latitude) > latitude);

            if (processedList.Count() > 0)
            {
                return true;
            }

            for (int i = 0; i <= 5; i++)
            {
                decimal leftLongitude = Decimal.Add(longitude, counter);
                var processedLeftList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == leftLongitude &&
                    Convert.ToDecimal(@w.Latitude) > latitude);

                decimal rightLatitude = Decimal.Subtract(longitude, counter);
                var processedRightList = cordinateList.Where(@w => Convert.ToDecimal(@w.Longitude) == rightLatitude &&
                    Convert.ToDecimal(@w.Latitude) > latitude);

                cordinates = cordinates.Union(processedList).Union(processedLeftList).Union(processedRightList).ToList();

                if (cordinates.Count() > 0)
                {
                    return true;
                }

                longitude = Decimal.Add(longitude, counter);
            }

            return false;
        }

        /// <summary>
        /// Eliminate LHS of the Cordinates from the Ward
        /// </summary>
        /// <param name="longWards"></param>
        private IList<Cordinate> EliminateLHSCordinate(Ward ward)
        {
            IList<Cordinate> cordinates = new List<Cordinate>();

            var cordinateList = context.Cordinates.Where(@w => @w.WardId.Equals(ward.Id));

            string top = ward.TopCordinate.Split(',')[1];
            IList<Cordinate> topList = cordinateList.Where(@w => @w.Longitude == top).ToList();
            int topRank = topList.OrderByDescending(@orderby => @orderby.Rank).First().Rank;

            string bottom = ward.BottomCordinate.Split(',')[1];
            IList<Cordinate> bottomList = cordinateList.Where(@w => @w.Longitude == bottom).ToList();
            int bottomRank = bottomList.OrderBy(@orderby => @orderby.Rank).First().Rank;

            if (topRank > bottomRank)
            {
                var list = cordinateList.Where(@w => @w.Rank <= topRank && @w.Rank >= bottomRank).ToList();
                cordinates = list;
            }
            else
            {
                var list = cordinateList.Where(@w => @w.Rank >= topRank && @w.Rank <= bottomRank).ToList();
                cordinates = list;
            }

            return cordinates;
        }

        private IList<Ward> GetWards(IList<Ward> wardList, decimal longitude)
        {
            IList<Ward> wards = new List<Ward>();

            foreach (var ward in wardList)
            {
                decimal left = Convert.ToDecimal(ward.LeftCordinate.Split(',')[1]);
                decimal right = Convert.ToDecimal(ward.RightCordinate.Split(',')[1]);

                if (longitude >= left && longitude <= right)
                {
                    wards.Add(ward);
                }
            }

            return wards;
        }

        private IList<Ward> GetWards(decimal latitude)
        {
            IList<Ward> wards = new List<Ward>();

            var wardList = context.Wards;

            foreach (var ward in wardList)
            {
                decimal top = Convert.ToDecimal(ward.TopCordinate.Split(',')[0]);
                decimal bottom = Convert.ToDecimal(ward.BottomCordinate.Split(',')[0]);

                if (latitude >= bottom && latitude <= top)
                {
                    wards.Add(ward);
                }
            }

            return wards;
        }

        /// <summary>
        /// InsertZoneDetails
        /// </summary>
        /// <param name="zoneNumber"></param>
        /// <param name="zoneName"></param>
        public void InsertZone(int zoneNumber, string zoneName)
        {
            Zone zone = new Zone
            {
                Id = Guid.NewGuid(),
                Name = zoneName,
                Number = zoneNumber
            };

            context.Zones.InsertOnSubmit(zone);
            SubmitData();
        }

        /// <summary>
        /// Submit Database Changes
        /// </summary>
        private void SubmitData()
        {
            context.SubmitChanges();
        }
    }
}
