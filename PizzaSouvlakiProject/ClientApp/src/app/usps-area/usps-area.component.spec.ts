import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UspsAreaComponent } from './usps-area.component';

describe('UspsAreaComponent', () => {
  let component: UspsAreaComponent;
  let fixture: ComponentFixture<UspsAreaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UspsAreaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UspsAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
