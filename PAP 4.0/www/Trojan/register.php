<?php
     $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');

     if(mysqli_connect_errno())
     {
 
         echo "1: Connection Failed"; //Erro 1 = conexão falhada
         exit();
 
     }
   
    $username = $_POST["name"];
    $password = $_POST["password"];

    $namecheckquery = "SELECT login FROM Jogador where login = '".$username. "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");
	
	if(mysqli_num_rows($namecheck)>0)
	{
		
		echo "3: Name already exits";
		exit();
	}
    
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
    $hash = crypt($password, $salt);

	$insertuserquery = "INSERT INTO Jogador (login, hash, salt, coins) 
    VALUES ('".$username."', '".$hash."', '".$salt."', 0);";
    
    mysqli_query($con, $insertuserquery) 
    or die("4: Falha ao inserir o utilizador");

	echo("0");	
?>