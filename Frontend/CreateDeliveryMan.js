function createDeliveryMan(data){
    const postData=
    {
        ID : null,
        Name : document.getElementById("Name").value,
        Location: document.getElementById("Location").value,
        DeliveryManStatus: document.getElementById("DeliveryManStatus").value,
        MobileNumber: document.getElementById("MobileNumber").value,
        DeliveryManType : [{ID : document.getElementById("MotorBike").value}]
    }
    const js = JSON.stringify(postData);
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function(){
        if(this.response != null){
            document.getElementById("response").innerHTML="OK";
        }
        else{
            document.getElementById("response").innerHTML="NO"; 
        }
    }
    xhttp.open("POST","https://localhost:44364/api/deliveryman/create",true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(js);
    return false;
    
    }