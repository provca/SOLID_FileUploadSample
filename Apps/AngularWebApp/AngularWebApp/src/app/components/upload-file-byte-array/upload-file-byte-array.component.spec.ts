import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadFileByteArrayComponent } from './upload-file-byte-array.component';

describe('UploadFileByteArrayComponent', () => {
  let component: UploadFileByteArrayComponent;
  let fixture: ComponentFixture<UploadFileByteArrayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UploadFileByteArrayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadFileByteArrayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
