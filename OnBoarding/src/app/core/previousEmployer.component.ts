import { Component, Inject } from "@angular/core";
import { NgForm } from "@angular/forms";
import { MODES, SharedState, SHARED_STATE } from "./sharedState.model";
import { Observable } from "rxjs";
import { Observer } from "rxjs";
import { Router } from "@angular/router";
import { PreviousEmployer } from "../model/previousemployer.model";
import { AreTheExitFormalitiesComplete } from "../model/AreTheExitFormalitiesComplete.model";
import { TypeOfPFAccount } from "../model/typeOfPFAccount.model";
import { PreviousEmployerModel } from "../model/previousEmployer.repository.model";
import { ThrowStmt } from '@angular/compiler';


@Component({
    selector: "peForm",
    templateUrl: "previousEmployer.component.html",
    styleUrls: ["previousEmployer.component.css"]
})

export class PreviousEmployerComponent
{
    previousEmployer: PreviousEmployer = new PreviousEmployer();
    areTheExitFormalitiesComplete: AreTheExitFormalitiesComplete[] = new Array<AreTheExitFormalitiesComplete>();
    typeOfPFAccount: TypeOfPFAccount[] = new Array<TypeOfPFAccount>();
    controlDetailsPE: PreviousEmployer = new PreviousEmployer();
    count:number = 1;
    personalEmployeeId: number =1;
    controlsPE = { controlDetailsPE: [] };
    href: string = "";
    isSummaryPage: boolean = false;

    constructor(private model: PreviousEmployerModel,
            private router: Router)
    {
        // this should be created in the Login Component
    }

    ngOnInit(): void 
    {
        this.href = this.router.url;
        console.log("URL " + this.href);
        if(this.href == "/form/summaryDetails")
        {
            this.isSummaryPage = true;
        }
        else
        {
            this.isSummaryPage = false;
        }
        
        this.controlsPE.controlDetailsPE = [this.controlDetailsPE];
        if(!this.editing)
        {
            //this.areTheExitFormalitiesCompleted.push(new AreTheExitFormalitiesCompleted(, "Please select"));
            this.areTheExitFormalitiesComplete.push(new AreTheExitFormalitiesComplete(false, "NO"));
            this.areTheExitFormalitiesComplete.push(new AreTheExitFormalitiesComplete(true, "YES"));
            //this.previousEmployer.areTheExitFormalitiesComplete = "Please select"

            //this.typeOfPFAccount.push(new TypeOfPFAccount(-1, "Please select"));
            this.typeOfPFAccount.push(new TypeOfPFAccount(1, "EPFO (Employee Provident Fund Office)"));
            this.typeOfPFAccount.push(new TypeOfPFAccount(2, "PF Trust"));
            //this.previousEmployer.typeOfPFAccount = "Please select"

        }          
        if(sessionStorage.getItem("PersonalDetailsEmployeeId"))
        {
            this.editing = false;
            this.personalEmployeeId = Number(sessionStorage.getItem("PersonalDetailsEmployeeId"));
            this.model.getPreviousEmployerByEmployeeId(this.personalEmployeeId).subscribe
                (data => {
                    if(data.length >= 1)
                    {
                        this.controlsPE.controlDetailsPE = data;
                        for (var val in data) {
                            if(val == "0")
                            {
                                if(data[val].areTheExitFormalitiesCompleted == true)
                                {
                                    this.controlsPE.controlDetailsPE[val].areTheExitFormalitiesComplete="YES";
                                }
                                else
                                {
                                    this.controlsPE.controlDetailsPE[val].areTheExitFormalitiesComplete="NO";
                                }
                            }
                        }

                        this.editing = true;
                    }
                });
        }
        else
        {
            this.editing = false;
            this.personalEmployeeId =-1
            this.router.navigateByUrl("/form/createpersonaldetails");
        }    
    }

    editing: boolean = false;

    addControlsPE(form: NgForm)
    {
      if(this.controlsPE.controlDetailsPE.length < 3 && form.valid)
      {
        const newControl = new PreviousEmployer;
        newControl.previousEmployerId=this.count++;
        this.controlsPE.controlDetailsPE.push(JSON.parse(JSON.stringify(newControl)));
      }    
    }
    submitForm(form: NgForm)
    {
        if(form.valid)
        {
            for (var val in this.controlsPE.controlDetailsPE) {
                this.previousEmployer = new PreviousEmployer();
                if(this.editing)
                {
                    this.previousEmployer.previousEmployerId=this.controlsPE.controlDetailsPE[val].previousEmployerId;
                }
                else
                {
                    this.previousEmployer.previousEmployerId= null;
                }
                this.previousEmployer.personalDetailEmployeeId = this.personalEmployeeId;
                this.previousEmployer.previousEmployerName = this.controlsPE.controlDetailsPE[val].previousEmployerName;
                this.previousEmployer.dateOfJoining = this.controlsPE.controlDetailsPE[val].dateOfJoining;
                this.previousEmployer.lastWorkingDay = this.controlsPE.controlDetailsPE[val].lastWorkingDay;
                this.previousEmployer.reasonForLeaving  = "NA";
                this.previousEmployer.universalAccountNo = 0;
                this.previousEmployer.providentFundNo = 0;
                this.previousEmployer.typeOfPFAccount = "NA";
                this.previousEmployer.isLatestLastEmployer = false;
                if(val == "0")
                {
                    this.previousEmployer.isLatestLastEmployer = true;
                    this.previousEmployer.reasonForLeaving = this.controlsPE.controlDetailsPE[val].reasonForLeaving;
                    this.previousEmployer.universalAccountNo = this.controlsPE.controlDetailsPE[val].universalAccountNo;
                    this.previousEmployer.providentFundNo = this.controlsPE.controlDetailsPE[val].providentFundNo;
                    this.previousEmployer.typeOfPFAccount = this.controlsPE.controlDetailsPE[val].typeOfPFAccount;
    
                }
                if(this.controlsPE.controlDetailsPE[val].areTheExitFormalitiesComplete =="YES")
                {
                    this.previousEmployer.areTheExitFormalitiesCompleted=true;
                }
                else
                {
                    this.previousEmployer.areTheExitFormalitiesCompleted=false;
                }
                console.log(this.previousEmployer);
                this.model.savePreviousEmployer(this.previousEmployer);
              }
           
           
            this.router.navigateByUrl("/form/groupMedicalCovers");
        }
    }

    getToday(): string {
        return new Date().toISOString().split('T')[0]
     }

    resetForm()
    {
        this.previousEmployer = new PreviousEmployer();
    }
    getPersonalDetailsPE()
    {
            this.router.navigateByUrl("/form/educationdetails");
    }
}