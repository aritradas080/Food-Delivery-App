function abc() {

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    <th>ID</th>
    <th>RID</th>
    <th>UID</th>
    <th>Restaurant-Name</th>
    <th>CAddress</th>
    <th>Date</th>
    <th>OrderStatus</th>
    <th>Amount</th>
                </tr>`;
    
        
          
            for (var i = 0; i < Object.keys(data).length; i++){
                row += `<tr>
                                <td>${data[i].Id}</td>
                                <td>${data[i].Rid}</td>
                                <td>${data[i].Uid}</td>                           
                                <td>${data[i].RestaurantName}</td>
                                <td>${data[i].Caddress}</td> 
                                <td>${data[i].Date}</td> 
                                <td>${data[i].OrderStatus}</td> 
                                <td>${data[i].Amount}</td> 
                          </tr>`

            }
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/orders", true);
      
      xhttp.send();
    
     
    return false;
     
     };