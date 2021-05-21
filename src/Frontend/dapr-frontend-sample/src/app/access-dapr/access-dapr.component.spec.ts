import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessDaprComponent } from './access-dapr.component';

describe('AccessDaprComponent', () => {
  let component: AccessDaprComponent;
  let fixture: ComponentFixture<AccessDaprComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccessDaprComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessDaprComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
