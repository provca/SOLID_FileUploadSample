import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
//import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { UploadFileFormComponent } from "./components/upload-file-form/upload-file-form.component";

const routes: Routes = [
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    { path: "uploadfileform", component: UploadFileFormComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
