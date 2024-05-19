<?php
   include("config/initialize.php");
   

   HTML :: head();
   $current_tab = " ";

   if(isset($_GET['tab']))
   {
    $current_tab = $_GET['tab'];
   }
   
   HTML :: sidebar($current_tab);
   HTML :: navbar();

   if($current_tab == "dashboard")
   {
      dashboard();
   }

   if($current_tab == "addclient")
   {
      addclient();
   }
   
   if($current_tab == "manage_clients")
   {
      client();
   }

   if($current_tab == "bill_records")
   {
      booking();
   }

   if($current_tab == "billing")
   {
      bbilling();
   }
   
   
   
   


   HTML ::footer();

?>
