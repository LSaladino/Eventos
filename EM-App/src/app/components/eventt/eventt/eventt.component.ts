import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Eventt } from 'src/app/models/eventt/eventt';
import { DialogService } from 'src/app/services/dialog/shared/dialog.service';
import { EventService } from 'src/app/services/event/shared/event.service';
import { FormatedDatePipe } from 'src/app/shared/pipes/formated-date.pipe';

@Component({
  selector: 'app-eventt',
  templateUrl: './eventt.component.html',
  styleUrls: ['./eventt.component.css'],
  providers: [FormatedDatePipe]
})
export class EventtComponent implements OnInit {

  ngOnInit(): void {
  }

  constructor(private fb: FormBuilder,
    private dialogService: DialogService,
    private eventService: EventService,
    private toastr: ToastrService,
    private datePipe: FormatedDatePipe
  ) {
    this.createEventForm();
    this.onGetEvents();
  }

  public oSelectedEvent!: Eventt;
  public eventForm!: FormGroup;
  public submitted: boolean = false;
  public oEvents: Eventt[] = [];
  public v_title = 'Eventos';
  public modo: string = '';
  public newEvent: Eventt = new Eventt();
  public oEvent!: Eventt;
  public eventMinute?: string;

  public myDateChoice!: moment.Moment;

  createEventForm() {
    this.eventForm = this.fb.group({
      id: [''],
      title: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(50)]],
      description: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(100)]],
      eventDate: ['', [Validators.required]],
      eventHour: ['', [Validators.required, Validators.min(0), Validators.max(23)]],
      eventMinute: ['', [Validators.required, Validators.min(0), Validators.max(59)]],
      place: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]]
    });
  }

  onEventSubmit() {
    this.submitted = true;

    if (this.eventForm.invalid) {
      return;;
    }

    this.eventForm.value.eventDate = this.datePipe.transform(this.eventForm.value.eventDate);
    this.eventForm.value.eventHour = this.eventForm.value.eventHour + ':' + this.eventForm.value.eventMinute;

    (this.oSelectedEvent?.id != 0) ? this.modo = 'put' : this.modo = 'post';

    if (this.modo == 'put') {
      this.onUpdateEvent(this.eventForm.value);
      this.toastr.success('Dado atualizado com sucesso !', 'EM Sytem');
    }

    if (this.modo == 'post') {
      this.newEvent = this.eventForm.value;
      this.newEvent.eventHour = this.eventForm.value.eventHour;
      this.onCreateEvent(this.newEvent);
    }

    this.onCloseForm();
  }

  onUpdateEvent(events: Eventt) {
    this.eventService.putEvent(events).subscribe({
      next: (eventRet: Eventt) => {
        console.log(eventRet)
        this.onGetEvents();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  onCreateEvent(newEvent: Eventt) {
    this.eventService.postEvent(newEvent).subscribe({
      next: (data: Eventt) => {
        if (data.id > 0) {
          this.toastr.info('Dado gravado com sucesso !', 'EM Sytem');
          this.onGetEvents();
          return;
        }
      },
      error: (err) => {
        this.toastr.error('Algo deu errado ! ' + err, 'EM Sytem');
      }
    })
  }

  onNewEvent() {
    this.oSelectedEvent = new Eventt();
    this.eventForm.patchValue(this.oSelectedEvent);
  }

  onGetEvents() {
    this.eventService.getAllEvent().subscribe({
      next: (data: Eventt[]) => {
        this.oEvents = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEventSelect(event: Eventt) {

    let p_Minute = event.eventHour.substring(5, 3);
    let p_Hour = event.eventHour.substring(2, 0);

    event.eventHour = p_Hour;
    event.eventMinute = p_Minute;

    this.oSelectedEvent = event;

    this.eventForm.patchValue(event);

  }

  onDelete(eventForm: Eventt) {
    this.dialogService.confirmDialog({
      title: 'EXCLUSÃO DE DADOS',
      message: `Confirma a exclusão ?  ID: ${eventForm.id} Nome: ${eventForm.title} ${eventForm.place}`,
      confirmText: 'Sim',
      cancelText: 'Não',
    },).subscribe(res => {
      if (res) {
        this.eventService.deleteEvent(eventForm.id).subscribe({
          next: () => {
            this.toastr.error('Registro excluído com sucesso !', 'EXCLUSÃO DE DADOS');
            this.onGetEvents();
          },
          error: (err) => {
            console.log(err);
          }
        })
      }

    })
  }

  onCloseForm() {
    this.oSelectedEvent = this.oEvent;
    this.onGetEvents();
  }

  clearEventForm() {
    // this.eventForm.reset(new Eventt());
    this.resetForm();
  }

  resetForm(value: any = undefined): void {
    this.eventForm.reset(value);
    (this as { submitted: boolean }).submitted = false;
  }

}