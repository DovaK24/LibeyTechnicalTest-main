import swal from 'sweetalert2';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentTypeService } from 'src/app/core/service/libeyuser/documentType.service';
import { RegionService } from 'src/app/core/service/libeyuser/region.service';
import { ProvinceService } from 'src/app/core/service/libeyuser/province.service';
import { UbigeoService } from 'src/app/core/service/libeyuser/ubigeo.service';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { Ubigeo } from 'src/app/entities/ubigeo';
import {DocumentType} from 'src/app/entities/documentType'
import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  @Input() dni?: string;

  libeyUser: LibeyUser = {} as LibeyUser;
  showSaveButton: boolean = false;
  showUpdateButton: boolean = false;
  showDeleteButton: boolean = false;
  documentTypes$?: Observable<DocumentType[]>;
  regions$?: Observable<Region[]>;
  provinces$?: Observable<Province[]>;
  ubigeos$?: Observable<Ubigeo[]>;

  selectedDocumentType?: number;
  selectedRegionCode: string = '';
  selectedProvinceCode: string = '';
  selectedUbigeoCode: string = '';
  
  documentNumber: string = '';
  name: string = '';
  paternalSurname: string = '';
  maternalSurname: string = '';
  address: string = '';
  phone: string = '';
  email: string = '';
  password: string = '';

  constructor(
    private documentTypeService: DocumentTypeService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private libeyUserService: LibeyUserService,
    private router: Router,
    private route: ActivatedRoute
  ) {}
  ngOnInit(): void {
    console.log("ingreso aqui ");
    this.documentTypes$ = this.documentTypeService.getAll();
    this.regions$ = this.regionService.getAll();
    this.showSaveButton = true;
    this.showUpdateButton = false;
    this.showDeleteButton = false;

    this.route.queryParams.subscribe(params => {
      const dni = params['dni'];
      if (dni) {
        console.log(dni);
        this.getUserByDni(dni);
      }
    });
  }

  getUserByDni(dni: string) {
    this.libeyUserService.Find(dni).subscribe({
      next: (user) => {
        if (user) {
          this.libeyUser = user;
          this.initializeForm();
          this.provinces$ = this.provinceService.getByRegion(this.selectedRegionCode);
          this.ubigeos$ = this.ubigeoService.getByProvinceAndRegion(this.selectedProvinceCode, this.selectedRegionCode); 
          this.showSaveButton = false;
          this.showUpdateButton = true;
          this.showDeleteButton = true;
        } else {
          swal.fire("Error!", "User not found!", "error");
          this.showSaveButton = true;
          this.showUpdateButton = false;
          this.showDeleteButton = false;
        }
      },
      error: (err) => {
        swal.fire("Error!", "Failed to retrieve user data!", "error");
        this.showSaveButton = true;
        this.showUpdateButton = false;
        this.showDeleteButton = false;
      }
    });
  }

  initializeForm() {
    this.selectedDocumentType = this.libeyUser.documentTypeId;
    this.selectedRegionCode = this.libeyUser.regionCode;
    this.selectedProvinceCode = this.libeyUser.provinceCode;
    console.log(this.selectedProvinceCode);
    console.log(this.libeyUser.provinceCode);
    this.selectedUbigeoCode = this.libeyUser.ubigeoCode;
    console.log(this.selectedUbigeoCode);
    console.log(this.libeyUser.ubigeoCode);
    this.documentNumber = this.libeyUser.documentNumber;
    this.name = this.libeyUser.name;
    this.paternalSurname = this.libeyUser.fathersLastName;
    this.maternalSurname = this.libeyUser.mothersLastName;
    this.address = this.libeyUser.address;
    this.phone = this.libeyUser.phone;
    this.email = this.libeyUser.email;
    this.password = this.libeyUser.password;
  }

  onRegionChange(regionCode: Region): void {
    this.selectedRegionCode = regionCode.regionCode;
    console.log(this.selectedRegionCode);
    this.provinces$ = this.provinceService.getByRegion(regionCode.regionCode);
  }

  onProvinceChange(provinceCode: Province): void {
    this.selectedProvinceCode = provinceCode.provinceCode;
    console.log(this.selectedProvinceCode);
    this.ubigeos$ = this.ubigeoService.getByProvinceAndRegion(provinceCode.provinceCode, this.selectedRegionCode);
  }

  onUbigeoChange(selectedUbigeo: Ubigeo): void {
    console.log(selectedUbigeo.ubigeoCode);
    this.selectedUbigeoCode = selectedUbigeo.ubigeoCode;
  }

  Submit() {

    this.libeyUser = {
      documentTypeId: this.selectedDocumentType!,
      documentNumber: this.documentNumber,
      name: this.name,
      fathersLastName: this.paternalSurname,
      mothersLastName: this.maternalSurname,
      address: this.address,
      phone: this.phone,
      email: this.email,
      password: this.password,
      ubigeoCode: this.selectedUbigeoCode,
      regionCode: this.selectedRegionCode,
      provinceCode: this.selectedProvinceCode, 
      active: true
    };

    this.libeyUserService.Create(this.libeyUser).subscribe({
      next: (response) => {
        swal.fire("Success!", "Se creó el usuario con exito!", "success");
        this.Clean();
      },
      error: (err) => {
        swal.fire("Error!", "Error al crear el usuario!", "error");
      }
    });
  }

  Update() {
		const updatedUser: LibeyUser = {
			documentNumber: this.documentNumber,
			documentTypeId: this.selectedDocumentType!,
			regionCode: this.selectedRegionCode,
			provinceCode: this.selectedProvinceCode,
			ubigeoCode: this.selectedUbigeoCode,
			name: this.name,
			fathersLastName: this.paternalSurname,
			mothersLastName: this.maternalSurname,
			address: this.address,
			phone: this.phone,
			email: this.email,
			password: this.password,
			active: this.libeyUser.active, // Mantén el estado actual del usuario
		};

		this.libeyUserService.Update(updatedUser).subscribe({
			next: (user) => {
        swal.fire("Success!", "Se actualizó el usuario con exito!", "success");
        this.Clean();
				// Redirige o realiza otras acciones si es necesario
			},
			error: (err) => {
				swal.fire("Error!", "Error al actualizar el usuario.", "error");
			}
		});
	}

  Delete() {
		swal.fire({
			title: '¿Estas seguro?',
			text: "No podrás revertirlo!",
			icon: 'warning',
			showCancelButton: true,
			confirmButtonColor: '#3085d6',
			cancelButtonColor: '#d33',
			confirmButtonText: 'Sí, eliminar!',
      cancelButtonText: 'Cancelar'
		}).then((result) => {
			if (result.isConfirmed) {
				this.libeyUserService.Delete(this.documentNumber).subscribe({
					next: () => {
						swal.fire('Eliminar!', 'Se eliminó correctamente.', 'success');
            this.Clean();
					},
					error: (err) => {
						swal.fire('Error!', 'No se pudo eliminar el usuario.', 'error');
					}
				});
			}
		});
	}

  Clean() {
		// Limpia todos los campos del formulario
		this.selectedDocumentType = 0;
		this.selectedRegionCode = '';
		this.selectedProvinceCode = '';
		this.selectedUbigeoCode = '';
		this.documentNumber = '';
		this.name = '';
		this.paternalSurname = '';
		this.maternalSurname = '';
		this.address = '';
		this.phone = '';
		this.email = '';
		this.password = '';
	}

  goBack() {
    this.router.navigate(['/user/card']);
  }
}