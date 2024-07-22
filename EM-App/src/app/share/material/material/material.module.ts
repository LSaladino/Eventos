import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//add modules to using material module for user
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports: [
    // --------------------------------------
    MatIconModule,
    MatButtonModule,
    // ----------------------
   
    MatDialogModule,
    // -----------------
   
  ]
})
export class MaterialModule { }