import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComprarFormComponent } from './comprar-form.component';

describe('ComprarFormComponent', () => {
  let component: ComprarFormComponent;
  let fixture: ComponentFixture<ComprarFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ComprarFormComponent]
    });
    fixture = TestBed.createComponent(ComprarFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
