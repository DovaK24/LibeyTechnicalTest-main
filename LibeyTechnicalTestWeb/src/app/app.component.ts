import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LibeyUserService } from './core/service/libeyuser/libeyuser.service';
import swal from 'sweetalert2';
import { LibeyUser } from './entities/libeyuser';

interface NavigationState {
  user?: LibeyUser;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LibeyTechnicalTest';
  searchDni: string = '';

  constructor(
    private router: Router
  ) {}

  onSearch() {
    if (this.searchDni) {
      this.router.navigate(['/user/maintenance'], { queryParams: { dni: this.searchDni } });
    } else {
      swal.fire("Error!", "Please enter a DNI to search.", "error");
    }
  }
}
