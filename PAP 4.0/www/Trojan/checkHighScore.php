<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {

        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();

    }

   $idUser = $_POST["idUser"];
   $score = $_POST["score"];
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


   $namecheckquery = "SELECT score
   FROM Score where idJogador = '".$idUser."'
   AND idMapa = '".$idMap."';";

   $namecheck = mysqli_query($con, $namecheckquery) or die("2: Falha ao conectar á bd");
   
   if(mysqli_num_rows($namecheck) == 0)
   {
    $insertuserquery = "INSERT INTO Score (score, idJogador, idMapa) 
    VALUES ('".$score. "', '".$idUser. "', '".$idMap. "');";

    mysqli_query($con, $insertuserquery) 
    or die("4: Falha ao inserir score");

   }else{

   $info = mysqli_fetch_assoc($namecheck);
   $highScore = $info["score"];

   if($highScore < $score){

    $insertuserquery = "UPDATE Score 
    SET score = '".$score. "'
    WHERE idJogador = '".$idUser. "'
    AND idMapa = '".$idMap."';";

    mysqli_query($con, $insertuserquery) 
    or die("5: Falha ao atualizar score");
   }}

?>