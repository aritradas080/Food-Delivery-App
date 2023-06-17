function update() {

      
  
    const xhttp = new XMLHttpRequest();
     xhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
      var user=JSON.parse(this.responseText);
       console.log(user.Id);
       document.getElementById("Name").value = user.Name;
        document.getElementById("Username").value= user.Username;
       document.getElementById("Password").value= user.Password;
       document.getElementById("Email").value= user.Email;
     


    }}
    
    xhttp.open("GET", "https://localhost:44364/api/admin/1", true);
    xhttp.setRequestHeader("Authorization", "16a0ddc7-ca3c-47ef-8182-61eeaa489848");
    
    xhttp.send();
  
  return false;
    }
  
  
  
    function profileupdate(pForm) {
  
  var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
          var user=JSON.parse(this.responseText)
          profileupdateppost(user);
          
          
             document.getElementById("response").innerHTML = "Update DOne";
          
      
      }
    };
  xhttp.open("GET", "https://localhost:44364/api/admin/1", true);
  xhttp.setRequestHeader("Authorization", "16a0ddc7-ca3c-47ef-8182-61eeaa489848");
    
    xhttp.send();
  
   
  return false;
   };
  
  function profileupdateppost(user) {
  
    const tosend=
    {
  
        Id: user.Id,
        Name:document.getElementById("Name").value,
        Username: document.getElementById("Username").value,
        Password: document.getElementById("Password").value,
        Email: document.getElementById("Email").value,
      

        
        
    }
    var xhttp = new XMLHttpRequest();
    const js=JSON.stringify(tosend);
    xhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
          
         
       
      }
    };
    
    xhttp.open("POST", "https://localhost:44364/api/admin/update");

    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("Authorization", "16a0ddc7-ca3c-47ef-8182-61eeaa489848");
    
    xhttp.send(js);
  
    
  };
  
  