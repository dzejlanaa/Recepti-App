import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditReceptComponent } from './edit-recept.component';

describe('EditReceptComponent', () => {
  let component: EditReceptComponent;
  let fixture: ComponentFixture<EditReceptComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditReceptComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditReceptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
