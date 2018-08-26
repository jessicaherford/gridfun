window.onload = function() {

 

       var triangleholder = document.getElementById(triangles);

      

       document.getElementById("getTriangles").addEventListener("click",

              function () {

                     document.getElementById("triangles").innerHTML = "";

                     var url = 'api/triangle';

                     return fetch(url) // Call the fetch function passing the url of the API as a parameter

                           .then((resp) => resp.json())

                           .then(function(data) {

                                  let triangles = data;

                                  for (tri in triangles) 
                                  {
                                         var trinode = `<div>${tri + " " + triangles[tri]}</div>`;

                                         document.getElementById("triangles").innerHTML += trinode;
                                  }

                           })

                           .catch(error => console.warn(error));

              });

 

       // GET api/triangle/byId?id=A1

       document.getElementById("getTriangleByID").addEventListener("click",

              function () {

                     document.getElementById("triangles").innerHTML = "";

                     var triID = document.getElementById("triangle-id").value;

                     var url = '/api/triangle/byId?id=' + triID;

                     fetch(url) // Call the fetch function passing the url of the API as a parameter

                           .then((resp) => resp.json())

                           .then(function (data) {

                                  let triangle = data;

                                  var trinode = `<div>${triID + " " + triangle}</div>`;

                                  document.getElementById("triangles").innerHTML += trinode;

                           })

                           .catch(error => document.getElementById("triangles").innerHTML += "Triangle Not Found Invalid Input");

              });

 

       // GET api/triangle/byCoords?coord1=0&coord2=0&coord3=10&coord4=10&coord5=0&coord6=10

       document.getElementById("getTriangleByCoords").addEventListener("click",

              function () {

                     document.getElementById("triangles").innerHTML = "";

                     var triCoord = document.getElementById("triangle-coords1").value;

                     var triCoord2 = document.getElementById("triangle-coords2").value;

                     var triCoord3 = document.getElementById("triangle-coords3").value;

                     var triCoord4 = document.getElementById("triangle-coords4").value;

                     var triCoord5 = document.getElementById("triangle-coords5").value;

                     var triCoord6 = document.getElementById("triangle-coords6").value;

 

                     console.log(triCoord);

                     var url = '/api/triangle/byCoords?coord1=' +

                           triCoord +

                           '&coord2=' +

                           triCoord2 +

                           '&coord3=' +

                           triCoord3 +

                           '&coord4=' +

                           triCoord4 +

                           '&coord5=' +

                           triCoord5 +

                           '&coord6=' +

                           triCoord6;

                     fetch(url) // Call the fetch function passing the url of the API as a parameter

                           .then((resp) => resp.json())

                           .then(function(data) {

                                  let triangle = data;

                                  var trinode = `<div>${Object.values(triangle)}</div>`;

                                  document.getElementById("triangles").innerHTML += trinode;

                           })
                           .catch(error => document.getElementById("triangles").innerHTML += "Triangle Not Found Invalid Input");

              });

}
