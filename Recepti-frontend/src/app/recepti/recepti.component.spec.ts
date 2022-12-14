import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceptiComponent } from './recepti.component';

describe('ReceptiComponent', () => {
  let component: ReceptiComponent;
  let fixture: ComponentFixture<ReceptiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceptiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceptiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
