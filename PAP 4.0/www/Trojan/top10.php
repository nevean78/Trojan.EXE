<?php

   $con = mysqli_connect('localhost', 'pap_goncalosilva', '0cDaJ4wo4QSo4T1y', 'pap_goncalosilva');
  
   // Check connection
   if(mysqli_connect_errno())
    {
        echo "1: Connection Failed"; //Erro 1 = conexão falhada
        exit();
    }

   $query = "SELECT j.login as login, s.score as score, m.nome as map
                      FROM Score s
                      join Jogador j on s.idJogador = j.id
                      join Mapas m on s.idMapa = m.id
                      order by s.score desc
                      LIMIT 10";

   $resultsArray = mysqli_query($con, $query) or die("7: Failed");

    $result = array();

   while($row = mysqli_fetch_assoc($resultsArray)) {
        array_push($result, (object)[
            'login' => $row["login"],
            'score' => $row["score"],
            'map' => $row["map"]
        ]);
   }

   echo json_encode($result);

?>

