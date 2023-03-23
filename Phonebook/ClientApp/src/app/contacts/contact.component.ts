import { Component, Inject, OnInit } from '@angular/core';
import { ContactService } from 'src/app/contacts/contact-service.service'

@Component({
  selector: 'app-contacts',
  templateUrl: './contact.component.html'
})
export class ContactComponent  {

  ContactList: any = [];
  ModalTitle = "";
  activateAddEditContactComp: boolean = false;
  contact: any;

  constructor(private service: ContactService, @Inject('BASE_URL') baseUrl: string) {
    service.apiUrl = baseUrl;
  }

  ngOnInit(): void {
    this.refreshContactList();
  }

  refreshContactList() {
    this.service.getContactList().subscribe(data => {
      this.ContactList = data;
    });
  }

  addClick() {
    this.contact = {
      id: "0",
      firstName: "",
      lastName: "",
      phoneNumber: ""

    }
    this.ModalTitle = "Add Contact";
    this.activateAddEditContactComp = true;
  }

  editClick(item: any) {
    this.contact = item;
    this.ModalTitle = "Edit Contact";
    this.activateAddEditContactComp = true;
  }

  deleteClick(item: any) {
    if (confirm('Are you sure??')) {
      this.service.deleteContact(item.id).subscribe(data => {
        alert("Contact Deleted");
        this.refreshContactList();
      })
    }
  }

  closeClick() {
    this.activateAddEditContactComp = false;
    this.refreshContactList();
  }
}
