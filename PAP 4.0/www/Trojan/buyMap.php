<?php

     $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');

     if(mysqli_connect_errno())
     {
 
         echo "1: Connection Failed"; //Erro 1 = conexão falhada
         exit();
 
     }
     
   
    $idMap = $_POST["idMap"];
    $idUser = $_POST["idUser"];
    $coins = $_POST["coins"];

    $query = "CALL comprarmapa('".$idUser."', '".$idMap."');";

    $mysqli = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');

    $result = $mysqli->query($query);
    $result = mysqli_fetch_assoc($result);
    
    echo $result["resultado"];
?>