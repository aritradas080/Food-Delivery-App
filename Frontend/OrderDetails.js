function showOrderDetails() {

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    <th>Id</th>
    <th>Pid</th>
    <th>Oid</th>
    <th>Price</th>
    <th>Quantity</th>
    
                </tr>`;
    
        
          
            for (var i = 0; i < Object.keys(data).length; i++){
                row += `<tr>
                                <td>${data[i].Id}</td>
                                <td>${data[i].Pid}</td>
                                <td>${data[i].Oid}</td>                           
                                <td>${data[i].Price}</td>
                                <td>${data[i].Quantity}</td> 
                                 
                          </tr>`

            }
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/allorderdetails", true);
      
      xhttp.send();
    
     
    return false;
     
     };