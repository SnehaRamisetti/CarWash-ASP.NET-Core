import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersordersComponent } from './usersorders.component';

describe('UsersordersComponent', () => {
  let component: UsersordersComponent;
  let fixture: ComponentFixture<UsersordersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersordersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
