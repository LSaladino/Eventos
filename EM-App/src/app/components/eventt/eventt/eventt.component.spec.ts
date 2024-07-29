import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventtComponent } from './eventt.component';

describe('EventtComponent', () => {
  let component: EventtComponent;
  let fixture: ComponentFixture<EventtComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EventtComponent]
    });
    fixture = TestBed.createComponent(EventtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
