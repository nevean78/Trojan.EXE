<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {

        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();

    }

   $idUser = $_POST["idUser"];
   $score = $_POST["coins"];
   $score = intval($score); 
   
   $coinscheckquery = "SELECT coins
   FROM Jogador where id = '".$idUser."';";

   $coinscheck = mysqli_query($con, $coinscheckquery) or die("2: Falha ao conectar á bd");

   $coinsinfo = mysqli_fetch_assoc($coinscheck);
   $coins = $coinsinfo["coins"];

   $coins = $coins + $score;

    $insertcoinsquery = "UPDATE Jogador 
    SET coins = '".$coins. "'
    WHERE id = '".$idUser. "';";

    mysqli_query($con, $insertcoinsquery) 
    or die("5: Falha ao atualizar coins");

    echo $coins;
?>