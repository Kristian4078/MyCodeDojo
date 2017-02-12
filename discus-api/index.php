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

	switch ($request) {
		case 'GET':
		 	//specify the columns that will be output by the api as a comma-delimited list
		  	$columns = "*";
		  	//setup the API
		  	$api = new API($host, 
	  				   $database, 
	  				   $table, 
	  				   $db_user, 
	  				   $db_password);
	  		$api->setup($columns);
	  		$api->set_default_order("actor_id");	  		
	  		$api->set_pretty_print(true);
	  		//If has filter add to the request and columns to filter
	  		//Hacky	  		
			if(isset($filter))
	  		{
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
			
			break;
		case 'PUT':
			
			break;
		case 'DELETE':
			
			break;
		default:
			echo $request . "is an invalid request";		
			break;
	}
	 
?>