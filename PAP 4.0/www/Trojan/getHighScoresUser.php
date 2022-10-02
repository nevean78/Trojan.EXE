<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {
        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();
    }

    $idUser = $_POST["idUser"];
    $map = $_POST["map"];

    switch ($map) {
     case $map == "Lvl1":
       $idMap = '1';
       break;
       case $map == "Lvl2":
         $idMap = '2';
       break;
       case $map == "Lvl3":
         $idMap = '3';
       break;     
   }

   $MapQuery = "SELECT score
   FROM Score
   where idJogador = '".$idUser. "' 
   and idMapa = '".$idMap. "';";

   $query = mysqli_query($con, $MapQuery) or die("2: Name check query failed");
   $MapScore = mysqli_fetch_assoc($query);

   if($MapScore == ''){
    $MapScore = '0'; 
   }

   $object = (object) ['mapScore' => $MapScore["score"]];

    echo json_encode($object);

?>

