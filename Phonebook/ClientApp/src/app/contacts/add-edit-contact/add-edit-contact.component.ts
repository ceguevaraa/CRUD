import { Component, OnInit, Input } from '@angular/core';
import { ContactService } from 'src/app/contacts/contact-service.service';

@Component({
  selector: 'app-add-edit-contact',
  templateUrl: './add-edit-contact.component.html',
})
export class AddEditContactComponent implements OnInit {

  constructor(private service: ContactService) { }

  @Input() contact: any;
  contactId = "";
  firstName = "";
  lastName = "";
  phoneNumber = "";


  ngOnInit(): void {

    this.contactId = this.contact.id;
    this.firstName = this.contact.firstName;
    this.lastName = this.contact.lastName;
    this.phoneNumber = this.contact.phoneNumber;

  }

  addContact() {
    var contact = {
      Id: this.contactId,
      FirstName: this.firstName,
      LastName: this.lastName,
      PhoneNumber: this.phoneNumber
    };
    this.service.addContact(contact).subscribe(res => {
      alert("Contact Created");
    });
  }

  updateContact() {
    var contact = {
      Id: this.contactId,
      FirstName: this.firstName,
      LastName: this.lastName,
      PhoneNumber: this.phoneNumber
    };
    this.service.updateContact(contact).subscribe(res => {
      alert("Contact Updated");
    });
  }
}
