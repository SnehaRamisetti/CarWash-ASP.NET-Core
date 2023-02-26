import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllpackageComponent } from './allpackage.component';

describe('AllpackageComponent', () => {
  let component: AllpackageComponent;
  let fixture: ComponentFixture<AllpackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllpackageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllpackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
