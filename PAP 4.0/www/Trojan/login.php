<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {

        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();

    }

   $username = $_POST["name"];
   $password = $_POST["password"];

   $namecheckquery = "SELECT id, login, salt, hash, coins 
   FROM Jogador
   where login = '".$username. "';";

   $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");
   
   if(mysqli_num_rows($namecheck) != 1)
   {
       echo "5: No user with name, or more than one";
       exit();
   }
   
   
   $logininfo = mysqli_fetch_assoc($namecheck);
   $salt = $logininfo["salt"];
   $hash = $logininfo["hash"];

   $loginhash = crypt($password, $salt);



   if($hash != $loginhash)
   {
       echo "6: Incorrect password";
       exit();
   }
   
   $scorefirstmapquery = "SELECT score 
   FROM Score
   where idJogador = '".$logininfo["id"]. "' AND idMapa = '1';";

   $scoresecondmapquery = "SELECT score 
   FROM Score
   where idJogador = '".$logininfo["id"]. "' AND idMapa = '2';";

   $scorethirdmapquery = "SELECT score 
   FROM Score
   where idJogador = '".$logininfo["id"]. "' AND idMapa = '3';";


   $scorefirstmap = mysqli_query($con, $scorefirstmapquery) or die("7: Failed");
   $scoresecondmap = mysqli_query($con, $scoresecondmapquery) or die("7: Failed");
   $scorethirdmap = mysqli_query($con, $scorethirdmapquery) or die("7: Failed");

   $scorefirstmapinfo = mysqli_fetch_assoc($scorefirstmap);
   $scoresecondmapinfo = mysqli_fetch_assoc($scoresecondmap);
   $scorethirdmapinfo = mysqli_fetch_assoc($scorethirdmap);

   if(mysqli_num_rows($scorefirstmap) != 1)
   {
    $scorefirstmapinfo["score"] = 0;      
   }

   if(mysqli_num_rows($scoresecondmap) != 1)
   {
    $scoresecondmapinfo["score"] = 0;      
   }

   if(mysqli_num_rows($scorethirdmap) != 1)
   {
    $scorethirdmapinfo["score"] = 0;      
   }


   $mapownedcheckquery = "SELECT id
   FROM MapasObtidos
   where idJogador = '".$logininfo["id"]. "'
   AND idMapa = '1';";

   $mapownedcheck = mysqli_query($con, $mapownedcheckquery) or die("7");
   
   if(mysqli_num_rows($mapownedcheck) == 0)
   {
       
    $insertDefaultMap = "INSERT INTO MapasObtidos (idJogador, idMapa) 
    VALUES ('".$logininfo["id"]. "', '1');";
    
    mysqli_query($con, $insertDefaultMap) 
    or die("Falha ao inserir mapa");

   }

   echo "0\t" . $logininfo["coins"]. "\t". $logininfo["id"]. "\t". $scorefirstmapinfo["score"]. "\t". $scoresecondmapinfo["score"]. "\t". $scorethirdmapinfo["score"];

?>

