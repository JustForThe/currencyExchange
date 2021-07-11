import { Component, OnInit } from '@angular/core';
import { AdminSettingsClient, MarkupVm, UpdateMarkupSettingCommand } from '../web-api-client';

@Component({
  selector: 'app-admin-settings',
  templateUrl: './admin-settings.component.html',
  styleUrls: ['./admin-settings.component.css']
})
export class AdminSettingsComponent implements OnInit {

  vm: MarkupVm;

  constructor(private markupClient: AdminSettingsClient) {
    markupClient.get().subscribe(
      result => {
        this.vm = result;
      },
      error => console.error(error)
    );
  }

  ngOnInit(): void {
  }

  checkMarkup() {
    if (this.vm.markupSettingPercentage > this.vm.maximumMarkupPercentage) {
      this.vm.markupSettingPercentage = this.vm.maximumMarkupPercentage;
      return;
    }
    if (this.vm.markupSettingPercentage < this.vm.minimunMarkupPercentage) {
      this.vm.markupSettingPercentage = this.vm.minimunMarkupPercentage;
      return;
    }
  }

  updateMarkup() {
    //$http.put("/api/test",                                       // 1. url
    //  {},                                                // 2. request body
    //  { params: { heroId: 123, power: "Death ray" } }   // 3. config object
    //);
    this.markupClient.update(UpdateMarkupSettingCommand.fromJS(
      {
        id: 1,
        markupSettingPercentage: this.vm.markupSettingPercentage
      }))
      .subscribe(
        () => console.log('Update succeeded.'),
        error => console.error(error)
      );
  }
}
