import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export class BaseService<TEntity extends { id: number }> {
  protected readonly controllerName: string | undefined;

  constructor(private httpClient: HttpClient) {}

  protected getUrl(actionName: string = ''): string {
    return (
      environment.serverUrl +
      '/' +
      environment.apiUrl +
      '/' +
      this.controllerName +
      (actionName ?? '/')
    );
  }

  public getAll(): Observable<TEntity[]> {
    let url = this.getUrl();
    return this.httpClient.get<TEntity[]>(url);
  }

  public create(record: TEntity): Observable<string> {
    let url = this.getUrl();
    return this.httpClient.post(url, record, { responseType: 'text' });
  }

  public update(record: TEntity): Observable<void> {
    let url = this.getUrl(`/${record.id}`);
    return this.httpClient.put<void>(url, record);
  }
}
