import { TestBed } from '@angular/core/testing';

import { UploadFileFormService } from './upload-file-form.service';

describe('UploadFileFormService', () => {
  let service: UploadFileFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UploadFileFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
