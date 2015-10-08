<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html {
            height: 100%;
        }

        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map_canvas {
            height: 100%;
        }
    </style>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js">    </script>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            getcordinates();
        });

        function getcordinates() {
            var myLatitudeLongitude = new google.maps.LatLng(12.98638, 77.62006)
            var mapOptions = {
                center: myLatitudeLongitude,
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

            google.maps.event.addListener(map, "click", function (event) {
                // get lat/lon of click
                var clickLatitude = event.latLng.lat();
                var clickLongitude = event.latLng.lng();

                // show in input box
                document.getElementById("txtLatitude").value = clickLatitude.toFixed(5);
                document.getElementById("txtLongitude").value = clickLongitude.toFixed(5);

                var latitude = document.getElementById("txtLatitude").value.replace(".", "_");
                var longitude = document.getElementById("txtLongitude").value.replace(".", "_");
                                
                var uri = '/api/ward/' + latitude + '/' + longitude + '/';

                // Send an AJAX request
                $.getJSON(uri)
                    .done(function (data) {
                        document.getElementById("lblDetails").textContent = 'Your ward is ' + data;
                    });
            });
        }
    </script>
</head>
<body>
    <form id="frmMain" runat="server">
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="updateDetails" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLatitude" runat="server" Text="Latitude"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLongitude" runat="server" Text="Longitude"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblDetails" runat="server" Text=""></asp:Label></td>
                                    `
                                    <td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <div id="map_canvas" style="width: 1200px; height: 700px"></div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
