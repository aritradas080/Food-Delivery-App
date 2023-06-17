function MonthlyIncomeDetails() {

    var xhttp = new XMLHttpRequest();
      xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var data=JSON.parse(this.responseText)
    var row=`<tr>
    <th>id</th>
    <th>month</th>
    <th>income</th>
                </tr>`;
    
        
          
            for (var i = 0; i < Object.keys(data).length; i++){
                row += `<tr>
                                <td>${data[i].id}</td>
                                <td>${data[i].month}</td>
                                <td>${data[i].income}</td>                                     
                          </tr>`

            }
           document.getElementById("table").innerHTML=row;
        
           
        }
      };
    xhttp.open("GET", "https://localhost:44364/api/monthlyincomes", true);
    xhttp.setRequestHeader("Authorization", "16a0ddc7-ca3c-47ef-8182-61eeaa489848");  
      xhttp.send();
    
     
    return false;
     
     };