function showAllRestaurants(){

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    <th>Id</th>
    <th>Name</th>
    <th>Location</th>
    <th>Username</th>
    <th>Password</th>
    <th>Status</th>
    <th>Rating</th>
    <th>Discount</th>
                </tr>`;
    
        
          
            for (var i = 0; i < Object.keys(data).length; i++){
                row += `<tr>
                                <td>${data[i].Id}</td>
                                <td>${data[i].Name}</td>                         
                                <td>${data[i].Location}</td>
                                <td>${data[i].Username}</td> 
                                <td>${data[i].Password}</td> 
                                <td>${data[i].Status}</td> 
                                <td>${data[i].Rating}</td>
                                <td>${data[i].Discount}</td>
                          </tr>`

            }
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/restaurants", true);
    xhttp.setRequestHeader("Authorization", "16a0ddc7-ca3c-47ef-8182-61eeaa489848");
      xhttp.send();
    
     
    return false;
     
     };