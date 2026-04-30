import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DbtcComponent } from './dbtc.component';

describe('DbtcComponent', () => {
  let component: DbtcComponent;
  let fixture: ComponentFixture<DbtcComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DbtcComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DbtcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
