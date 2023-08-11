import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesarrolladoresComponent } from './desarrolladores.component';

describe('DesarrolladoresComponent', () => {
  let component: DesarrolladoresComponent;
  let fixture: ComponentFixture<DesarrolladoresComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DesarrolladoresComponent]
    });
    fixture = TestBed.createComponent(DesarrolladoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
