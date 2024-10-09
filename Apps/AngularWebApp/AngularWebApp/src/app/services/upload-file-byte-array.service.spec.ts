import { TestBed } from '@angular/core/testing';

import { UploadFileByteArrayService } from './upload-file-byte-array.service';

describe('UploadFileByteArrayService', () => {
  let service: UploadFileByteArrayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UploadFileByteArrayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
