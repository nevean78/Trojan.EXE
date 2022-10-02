<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {
        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();
    }

   $idUser = $_POST["idUser"];

   $firstMapQuery = "SELECT id
   FROM MapasObtidos
   where idJogador = '".$idUser. "' 
   and idMapa = '1';";
   
   $secondMapQuery = "SELECT id
   FROM MapasObtidos
   where idJogador = '".$idUser. "'  
   and idMapa = '2';";

   $thirdMapQuery = "SELECT id
   FROM MapasObtidos
   where idJogador = '".$idUser. "' 
   and idMapa = '3';";

   $queryFirst = mysqli_query($con, $firstMapQuery) or die("2: Name check query failed");
   $fisrtMapOwned = mysqli_fetch_assoc($queryFirst);

   $querySecond = mysqli_query($con, $secondMapQuery) or die("2: Name check query failed");
   $secondMapOwned = mysqli_fetch_assoc($querySecond);

   $queryThird = mysqli_query($con, $thirdMapQuery) or die("2: Name check query failed");
   $thirdMapOwned = mysqli_fetch_assoc($queryThird);

   if($fisrtMapOwned == ''){
    $fisrtMapOwned = 'false'; 
   }else{
    $fisrtMapOwned = 'true'; 
   }

   if($secondMapOwned == ''){
    $secondMapOwned = 'false'; 
   }else{
    $secondMapOwned = 'true'; 
   }

   if($thirdMapOwned == ''){
    $thirdMapOwned = 'false'; 
   }else{
    $thirdMapOwned = 'true'; 
   }

   $secondMapPriceQuery = "SELECT preco
   FROM Mapas
   where id = '2';";

   $thirdMapPriceQuery = "SELECT preco
   FROM Mapas
   where id = '3';";

   $querySecondMapPrice = mysqli_query($con, $secondMapPriceQuery) or die("2: Name check query failed");
   $secondMapPrice = mysqli_fetch_assoc($querySecondMapPrice);

   $queryThirdMapPrice = mysqli_query($con, $thirdMapPriceQuery) or die("2: Name check query failed");
   $thirdMapPrice = mysqli_fetch_assoc($queryThirdMapPrice);
   
   $object = (object) ['Lvl1' => $fisrtMapOwned, 'Lvl2' => $secondMapOwned, 'Lvl3' => $thirdMapOwned, 'Lvl2Price' => $secondMapPrice["preco"], 'Lvl3Price' => $thirdMapPrice["preco"]];

    echo json_encode($object);

?>

