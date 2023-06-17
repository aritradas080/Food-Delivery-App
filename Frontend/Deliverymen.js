function abc() {

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    <th>ID</th>
    <th>Name</th>
    <th>Rating</th>
    <th>Location</th>
    <th>DeliveryManStatus</th>
    <th>MobileNumber</th>
                </tr>`;
    
        
          
            for (var i = 0; i < Object.keys(data).length; i++){
                row += `<tr>
                                <td>${data[i].ID}</td>
                                <td>${data[i].Name}</td>
                                <td>${data[i].Rating}</td>                           
                                <td>${data[i].Location}</td>
                                <td>${data[i].DeliveryManStatus}</td> 
                                <td>${data[i].MobileNumber}</td> 
                              
                          </tr>`

            }
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/deliveryman", true);
      
      xhttp.send();
    
     
    return false;
     
     };