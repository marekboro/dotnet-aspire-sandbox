import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  private router = inject(Router);
  constructor() { }

  ngOnInit(): void {
  }
  go(route: string){
    this.router.navigateByUrl(route)
  }

}
