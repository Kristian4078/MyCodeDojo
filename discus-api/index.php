<?php
//include the API Builder mini lib
	 	require_once("api_builder_includes/class.API.inc.php");		
	 //set page to output JSON
	 header("Content-Type: application/json; charset=utf-8");

	 $host = "127.0.0.1";
	 $database = "sakila";
	 $db_user = "root";
	 $db_password = "Lizzard.2016";

	$uri = explode("/", $_SERVER["REQUEST_URI"]);
	$request = strtoupper($uri[1]);
	$table = strtolower($uri[2]);	
	if(isset($uri[3]))
	{
		$filter = explode("=", strtolower($uri[3]));
	}

		$api = new API($host, 
			   $database, 
			   $table, 
			   $db_user, 
			   $db_password);	
	
	switch ($request) {
		case 'GET':				
		 	//specify the columns that will be output by the api as a comma-delimited list		  	
		  	//setup the API		  	
	  		$api->setup("*");
	  		//$api->set_default_order("actor_id");	  		
	  		$api->set_pretty_print(true);
	  		//If has filter add to the request and columns to filter
	  		//Hacky	  		
			if(isset($filter))
	  		{
	  			$_GET["exact"] = "true";
	  			$_GET[$filter[0]] = $filter[1];
	  			$api->columns_to_provide_array[] = $filter[0];
	  		}
	  		//sanitize the contents of $_GET to insure that 
	  		//malicious strings cannot disrupt your database	  	  			  
	 		$get_array = Database::clean($_GET);	 		
	 		//output the results of the http request
	 		echo $api->get_json_from_assoc($get_array);
	 		exit();				
			break;	
		case 'POST':   
			var_dump($_POST);
			print $_POST["data"] . "<br>";
			print "test";

			exit();
			$_POST = array();
			$_POST["city_id"] = 601;	
			$_POST["city"] = "Birmingham";
			$_POST["country_id"] = 102;
            // Sanitize the array so that it can be safely inserted into the database.
            // This method uses MySQLi real escape string and htmlspecialchars encoding.

            $post_array = Database::clean($_POST);
                        print_r($post_array);



            if(Database::execute_from_assoc($post_array, Database::$table)){
                echo "The data was submitted to the database";
            }else echo "There was an error submitting the data to the database";
			break;
		case 'PUT':
			
			break;
		case 'DELETE':
			
			break;
		default:
			if(empty($request))
			{
				echo "please use a valid request e.g. /get, /put, /post";
			}
			else
			{
				echo $request . "is an invalid request";		
			}
			break;
	}
	 
?>