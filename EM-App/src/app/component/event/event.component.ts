import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Eventt } from 'src/app/models/eventt/eventt';
import { DialogService } from 'src/app/services/dialog.service';
import { EventserviceService } from 'src/app/services/eventservice.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {

  ngOnInit(): void {

  }

  constructor(private fb: FormBuilder,
    private dialogService: DialogService,
    private eventService: EventserviceService,
    private toastr: ToastrService
  ) {
    this.createEventForm();
  }

  public oSelectedEvent!: Eventt;
  public eventForm!: FormGroup;
  public submitted: boolean = false;
  public oEvents: Eventt[] = [];
  public v_title = 'Eventos';
  public modo: string = '';
  public newEvent: Eventt = new Eventt();
  public oEvent!: Eventt;


  createEventForm() {
    this.eventForm = this.fb.group({
      id: [''],
      title: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(50)]],
      description: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(100)]],
      date: ['', [Validators.required]],
      hour: ['', [Validators.required]],
      place: ['', [Validators.required]]
    });
  }

  onEventSubmit() {
    this.submitted = true
    if (this.eventForm.invalid) {
      return
    }

    (this.oSelectedEvent?.id != 0) ? this.modo = 'put' : this.modo = 'post';

    if (this.modo == 'put') {
      this.onUpdateEvent(this.eventForm.value);
      this.toastr.success('Dado atualizado com sucesso !', 'SmartSchool Hint');
    }

    if (this.modo == 'post') {
      this.newEvent = this.eventForm.value;
      this.onCreateEvent(this.newEvent);
      this.toastr.info('Dado gravado com sucesso !', 'SmartSchool Hint');
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
      next: (eventRet: Eventt) => {
        this.onGetEvents();
        console.log('Novo evento: ' + eventRet);
      },
      error: (err) => {
        console.log('Found errors: ' + err);
      }
    })
  }

  onNewEvent() {
    this.oSelectedEvent = new Eventt();
    this.eventForm.patchValue(this.oSelectedEvent);
  }

  onGetEvents() {
    this.eventService.getAllEvent().subscribe({
      next: (events: Eventt[]) => {
        this.oEvents = events;
      },
      error: (err) => {
        console.log('somethings wrong occurred: ' + err);
      }
    });
  }

   //  getname dont use, only in the initial of trainning
   onEventSelect(event: Eventt) {
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
            this.toastr.error('Registro excluído com sucesso !','EXCLUSÃO DE DADOS');
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
  }

  clearEventForm() {
    this.eventForm.reset(new Eventt());
  }

}
