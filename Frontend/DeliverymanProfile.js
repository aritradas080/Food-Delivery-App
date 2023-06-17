function abc() {

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    
    <th>Name</th>
    <th>Rating</th>
    <th>Location</th>
    <th>DeliveryManStatus</th>
    <th>MobileNumber</th>
    
                </tr>

                <tr>
                               
                                <td>${data.Name}</td>
                                <td>${data.Rating}</td>                           
                                <td>${data.Location}</td>
                                <td>${data.DeliveryManStatus}</td> 
                                <td>${data.MobileNumber}</td> 
                                
                          </tr>`

            
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/deliveryman/1", true);
      
      xhttp.send();
    
     
    return false;
     
     };