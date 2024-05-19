<!-- Layout wrapper -->
<div class="layout-wrapper layout-content-navbar">
  <?php
  // Check if user ID is present in the URL parameters
  ?>
  <div class="layout-container">
    <!-- Menu -->

    <aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">
      <div>
        <div class="app-brand demo">
          <a href="index.php" class="app-brand-link">
            <span class="app-brand-logo">
              <img src="assets/img/avatars/logo.png" height="60px" width="70px" alt="User Circle">
            </span>
            <span class="app-brand-text menu-text fw-bolder ms-2">WATER BILLING <br></span>
          </a>

        </div>
        <div class="menu-inner-shadow"></div>

        <ul class="menu-inner py-1">
          <!-- Dashboard -->
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'dashboard') {
                                  echo 'active';
                                } ?> ">
            <a href="home.php?tab=dashboard" class="menu-link">
              <i class="menu-icon tf-icons bx bxs-home-circle"></i>
              <div data-i18n="Analytics">Dashboard</div>
            </a>
          </li>


          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'client' || $current_tab == 'manage_clients') {
                                  echo 'active open';
                                } ?>">
            <a href="javascript:void(0);" class="menu-link menu-toggle">
              <i class="menu-icon tf-icons bx bxs-category"></i>
              <div data-i18n="Account Settings">Clients</div>
            </a>
            <ul class="menu-sub">
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'client') {
                                      echo 'active';
                                    } ?>">
                <a href="home.php?tab=addclient" class="menu-link">

                  <div data-i18n="Account">Add Clients</div>
                </a>
              </li>
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'manage_clients') {
                                      echo 'active ';
                                    } ?> ">
                <a href="home.php?tab=manage_clients" class="menu-link">

                  <div data-i18n="Notification">Manage Clients</div>
                </a>
              </li>

            </ul>
          </li>
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'menu' || $current_tab == 'manage_menu') {
                                  echo 'active open';
                                } ?>">
            <a href="home.php?tab=billing" class="menu-link ">
              <i class="menu-icon tf-icons bx bx-list-plus"></i>
              <div data-i18n="Account Settings">Billing</div>
            </a>
            
          </li>
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'bill_records') {
                                  echo 'active';
                                } ?> ">
                                
            <a href="home.php?tab=bill_records" class="menu-link">
              <i class="menu-icon tf-icons bx bxs-dollar-circle"></i>
              <div data-i18n="Analytics">Bill Records</div>
            </a>
          </li>

          <li class="menu-item ">
            <a href="#" class="menu-link" onclick="confirmLogout()">
              <i class="bx bx-power-off me-2"></i>
              <span class="align-middle">Log Out</span>
            </a>
          </li>
        </ul>
      </div>
    </aside>
    <script>
      function confirmLogout() {
        if (confirm("Are you sure you want to log out?")) {
          window.location.href = "config/classes/logout.php";
        }
      }
    </script>
    <!-- / Menu -->