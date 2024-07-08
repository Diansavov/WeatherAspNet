var map = L.map('map').setView([51.505, -0.09], 13);

const z = 0;
const x = 0;
const y = 0;

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

const basemaps = {
    StreetMap: L.tileLayer(`https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png`,   {attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'}),
    Temperature: L.tileLayer.wms(`https://tile.openweathermap.org/map/temp_new/{z}/{x}/{y}.png?appid=fe747b888173572352b880928ec52948`,   {layers: 'TOPO-WMS'}),
    Wind: L.tileLayer.wms(`https://tile.openweathermap.org/map/wind_new/{z}/{x}/{y}.png?appid=fe747b888173572352b880928ec52948`, {layers: 'OSM-Overlay-WMS'})
  };
  
  L.control.layers(basemaps).addTo(map);
  basemaps.Topography.addTo(map);  