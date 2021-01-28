import { from } from "rxjs";
import { NgModule } from "@angular/core";
import { StaticDataSource } from "./static.datasource";
import { PersonalDetailsModel } from "./personalDetails.repository.model";
import { HttpClientModule } from "@angular/common/http";
import { PersonalDetailsRestDataSource, REST_URL } from "./personalDetails.rest.datasource";
import { OtpgeneratorRestDatasource,REST_URL_OTP } from "./otpgenerator.rest.datasource";
import { OtpGeneratorsModel } from "./otpgenerator.repository.model";
import { EducationQualificationRestDataSource,REST_URL_EQ } from "./education-Qualification.rest.datasource";
import { EducationQualificationModel } from "./educationQualification.repository.model";
import { EducationCertificationRestDataSource,REST_URL_EC } from "./educationcertification.rest.datasource";
import { EducationCertificationModel } from "./educationcertification.repository.model";
import { PreviousEmployerRestDataSource,REST_URL_PE } from "./previousEmployer.rest.datasource";
import { PreviousEmployerModel } from "./previousEmployer.repository.model";
import { GroupMedicalRestDataSource,REST_URL_GM } from "./groupMedical.rest.datasource";
import { GroupMedicalModel } from "./groupMedical.repository.model";
import { KidRestDataSource,REST_URL_Kid } from "./kid.rest.datasource";
import { KidModel } from "./kid.repository.model";

//import { TestComponent } from './test/test.component';

@NgModule({
    imports: [HttpClientModule],
    providers: [PersonalDetailsModel, PersonalDetailsRestDataSource,
        OtpgeneratorRestDatasource,OtpGeneratorsModel,
        EducationQualificationRestDataSource,EducationQualificationModel,
        EducationCertificationRestDataSource,EducationCertificationModel,
        PreviousEmployerRestDataSource,PreviousEmployerModel,
        GroupMedicalRestDataSource,GroupMedicalModel,
        KidRestDataSource,KidModel,

    {provide: REST_URL, useValue: `https://localhost:5001/api/personaldetails`},
    {provide: REST_URL_OTP, useValue: `https://localhost:5001/api/otpGenerators`},
    {provide: REST_URL_EQ, useValue: `https://localhost:5001/api/educationqualifications`},
    {provide: REST_URL_EC, useValue: `https://localhost:5001/api/educationcertifications`},
    {provide: REST_URL_PE, useValue: `https://localhost:5001/api/previousEmployers`},
    {provide: REST_URL_GM, useValue: `https://localhost:5001/api/groupMedicalCovers`},
    {provide: REST_URL_Kid, useValue: `https://localhost:5001/api/kids`}
    ],
    declarations: []
})

export class ModelModule {}
