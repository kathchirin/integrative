<?php
require_once('classes/database.php');
require_once('classes/session.php');
require_once('config/classes/htmlclass.php');
require_once('components/pages/addclient.php');
require_once('components/pages/dashboard.php');
require_once('components/pages/clients.php');
require_once('components/pages/booking.php');
require_once('components/pages/billing.php');
require_once('components/pages/viewbilling.php');


// Database configuration
$db_host = 'localhost';
$db_user = 'root';
$db_pass = '';
$db_name = 'waterbilling';

// Create database connection
$database = new Database("mysql:host={$db_host};dbname={$db_name}", $db_user, $db_pass);

$session = new Session;
$session->db_connect(); 

?>
