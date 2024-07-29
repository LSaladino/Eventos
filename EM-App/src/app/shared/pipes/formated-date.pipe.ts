import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({
  name: 'formatedDate'
})
export class FormatedDatePipe implements PipeTransform {

  transform(date: string): string {

    let dateOut: moment.Moment = moment(date, "YYYY-MM-DDTHH:mm:ss");
    return dateOut.format("YYYY-MM-DDT00:00:00");
  }

}
