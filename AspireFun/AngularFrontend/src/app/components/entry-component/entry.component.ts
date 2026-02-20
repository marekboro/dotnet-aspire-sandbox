import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { ServerService } from '../../services/server.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { TestResponse } from 'src/app/models/testResponse';

@Component({
  selector: 'app-entry-component',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.css'],
  standalone: true,
  imports: [CommonModule, RouterModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EntryComponent {
  private serverService = inject(ServerService);

  data1$: Observable<TestResponse> = this.serverService.getData1(); 
  data2$: Observable<TestResponse> = this.serverService.getData2(); 
}
