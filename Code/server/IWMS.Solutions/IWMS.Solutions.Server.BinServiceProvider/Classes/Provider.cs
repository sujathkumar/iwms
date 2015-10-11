﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWMS.Solutions.Server.BinServiceProvider.Models;

namespace IWMS.Solutions.Server.BinServiceProvider
{
    public class Provider
    {
        #region Members
        private BinServiceModelDataContext context = null;
        #endregion

        #region Constructor
        public Provider()
        {
            if (context == null)
            {
                context = new BinServiceModelDataContext();
            }
        }
        #endregion

        /// <summary>
        /// RetrieveHHUserInfo
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int RetrieveHHUserInfo(string key)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var registerdUser = context.Addresses.Where(@w => @w.UserId == user.UserId).First();

                if (!registerdUser.Registered)
                {
                    return 205;
                }
                else
                {
                    var bin = context.Bins;

                    if (bin != null && bin.Count() > 0)
                    {
                        int status = Convert.ToInt32(bin.First().Status);

                        if (status == 0)
                        {
                            return 206;
                        }
                        else if (status == 1)
                        {
                            return 207;
                        }
                        else if (status == 2)
                        {
                            return 208;
                        }
                    }
                    else
                    {
                        return 205;
                    }
                }
            }
            catch (Exception ex)
            {
                return 100;
            }

            return 100;
        }

        /// <summary>
        /// RetrieveGarbageTag
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RetrieveGarbageTag(string key)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var bin = context.Bins.Where(@w => @w.UserId == user.UserId).First();
                var garbage = context.Garbages.Where(@w => @w.BinId == bin.Id).First();

                return garbage.Tag;
            }
            catch (Exception ex)
            {
                return "100";
            }
        }

        /// <summary>
        /// InsertAddress
        /// </summary>
        /// <param name="key"></param>
        /// <param name="houseNo"></param>
        /// <param name="houseName"></param>
        /// <param name="ApartmentName"></param>
        /// <param name="street"></param>
        /// <param name="locality"></param>
        /// <param name="ward"></param>
        /// <param name="registered"></param>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public int InsertAddress(string key, string houseNo, string houseName, string ApartmentName, string street, string locality, string ward, bool registered, int pincode)
        {
            try
            {
                var user = context.Auths.Where(@w => @w.Key == key).First();
                var addressSingle = context.Addresses.Where(@w => @w.UserId == user.UserId).First();
                var selectedWard = context.Wards.Where(@w => @w.Name.ToLower() == ward.ToLower()).First();

                addressSingle.Id = addressSingle.Id;
                addressSingle.HouseNo = houseNo;
                addressSingle.HouseName = houseName;
                addressSingle.ApartmentName = ApartmentName;
                addressSingle.Street = street;
                addressSingle.Locality = locality;
                addressSingle.WardId = selectedWard.Id;
                addressSingle.PINCODE = pincode;
                addressSingle.Registered = registered;
                addressSingle.UserId = user.UserId;

                SubmitData();

                return 209;

            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertBin
        /// </summary>
        /// <param name="key"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int InsertBin(string key, string status)
        {
            try
            {
                var userId = context.Auths.Where(@w => @w.Key == key).First().UserId;
                short binStatus = Convert.ToInt16(status);
                Guid binId = Guid.NewGuid();

                Bin bin = new Bin
                {
                    Id = binId,
                    Status = binStatus,
                    UserId = userId
                };

                context.Bins.InsertOnSubmit(bin);
                InsertGarbage(binId, userId);
                SubmitData();
                return 210;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// InsertGarbage
        /// </summary>
        /// <param name="binId"></param>
        private int InsertGarbage(Guid binId, Guid userId)
        {
            try
            {
                var garbageId = Guid.NewGuid();
                var tag = GenerateTag(userId);
                Garbage garbage = new Garbage
                {
                    Id = garbageId,
                    Tag = tag,
                    BinId = binId
                };

                context.Garbages.InsertOnSubmit(garbage);
                SubmitData();

                return 211;
            }
            catch (Exception ex)
            {
                return 100;
            }
        }

        /// <summary>
        /// GenerateTag
        /// </summary>
        /// <returns></returns>
        public string GenerateTag(Guid userId)
        {
            string generatedTag = "";
            int tagNumber = 1;

            var address = context.Addresses.Where(@w => @w.UserId == userId).First();
            var ward = context.Wards.Where(@w => @w.Id == address.WardId).First();
            var zone = context.Zones.Where(@w => @w.Id == ward.ZoneId).First();

            var wardTag = context.WardTags.Where(@w => @w.WardId == ward.Id);

            if (wardTag != null && wardTag.Count() > 0)
            {
                tagNumber = wardTag.First().TagNo + 1;
                generatedTag = "Z" + zone.Number + "-W" + ward.Number + "-" + tagNumber;
                wardTag.First().TagNo = tagNumber;
            }
            else
            {
                WardTag tag = new WardTag
                {
                    Id = Guid.NewGuid(),
                    TagNo = tagNumber,
                    WardId = ward.Id
                };

                generatedTag = "Z" + zone.Number + "-W" + ward.Number + "-" + tagNumber;
                context.WardTags.InsertOnSubmit(tag);
            }

            SubmitData();


            return generatedTag;
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