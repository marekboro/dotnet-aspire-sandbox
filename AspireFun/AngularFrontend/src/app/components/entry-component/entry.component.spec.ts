import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntryComponent } from './entry.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ServerService } from 'src/app/services/server.service';
import { AspireServerApiHttpClient } from 'src/app/apiHttpClient';
import { HttpHandler } from '@angular/common/http';

describe('EntryComponent', () => {
  let component: EntryComponent;
  let fixture: ComponentFixture<EntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonModule, RouterModule],
      providers: [ServerService, AspireServerApiHttpClient, HttpHandler],
    }).compileComponents();

    fixture = TestBed.createComponent(EntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
