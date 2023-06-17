function update() {

      
  
    const xhttp = new XMLHttpRequest();
     xhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
      var user=JSON.parse(this.responseText);
       console.log(user.ID);
       document.getElementById("Name").value = user.Name;
        document.getElementById("Username").value= user.Username;
       document.getElementById("Password").value= user.Password;
       document.getElementById("Rating").value= user.Rating;
       document.getElementById("Location").value= user.Location;
       document.getElementById("DeliveryManStatus").value= user.DeliveryManStatus;
       document.getElementById("MobileNumber").value= user.MobileNumber;
       document.getElementById("dtId").value= user.dtId;


    }}
    
    xhttp.open("GET", "https://localhost:44364/api/deliveryman/2", true);
    xhttp.setRequestHeader("Authorization", "25162783-e267-4ba7-951f-df42cb68da84");
    
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
  xhttp.open("GET", "https://localhost:44364/api/deliveryman/2", true);
  xhttp.setRequestHeader("Authorization", "25162783-e267-4ba7-951f-df42cb68da84");
    
    xhttp.send();
  
   
  return false;
   };
  
  function profileupdateppost(user) {
  
    const tosend=
    {
  
        ID: user.ID,
        Name:document.getElementById("Name").value,
        Username: document.getElementById("Username").value,
        Password: document.getElementById("Password").value,
        Rating: document.getElementById("Rating").value,
        Location: document.getElementById("Location").value,
        DeliveryManStatus:  document.getElementById("DeliveryManStatus").value,
        MobileNumber:  document.getElementById("MobileNumber").value,
        dtId:  document.getElementById("dtId").value

        
        
    }
    var xhttp = new XMLHttpRequest();
    const js=JSON.stringify(tosend);
    xhttp.onreadystatechange = function() {
      if (this.readyState == 4 && this.status == 200) {
          
         
       
      }
    };
    
    xhttp.open("POST", "https://localhost:44364/api/deliveryman/update");

    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.setRequestHeader("Authorization", "25162783-e267-4ba7-951f-df42cb68da84");
    
    xhttp.send(js);
  
    
  };
  
  