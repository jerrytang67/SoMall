import { Component, OnInit, Input, ViewChild, } from '@angular/core';
import { ControlAnchor, MapOptions, MapTypeControlOptions, MapTypeControlType, NavigationControlOptions, NavigationControlType, OverviewMapControlOptions, ScaleControlOptions, BNavigationControl, BOverviewMapControl, MarkerOptions, Animation, MapTypeEnum, GeolocationControlOptions, CircleOptions, Point, BCircle, BMarker, BMapInstance } from 'angular2-baidu-map'

@Component({
    selector: 'tt-map',
    template: `<baidu-map #map [options]="options"  style="display: block; width: 100vw; height: 500px;">
  <marker
   *ngFor="let marker of markers"
   [point]="marker.point"
   [options]="marker.options"
   (clicked)="showWindow($event,marker)"
   (loaded)="setAnimation($event)" >
  </marker>
    <control type="navigation" [options]="navOptions"></control>
</baidu-map>`
})
export class TtMapComponent implements OnInit {

    @ViewChild("map") map: any

    @Input() options: MapOptions;

    @Input() markers: Array<{ point: Point; options?: MarkerOptions; info?: { title: string, content: string } }>

    ngOnInit() {
    }
    point: Point
    navOptions: NavigationControlOptions

    constructor() {
        this.markers = [
            {
                options: {
                    icon: {
                        imageUrl: '/assets/markericon.png',
                        size: {
                            height: 35,
                            width: 25
                        },
                        imageSize: {
                            height: 35,
                            width: 25
                        }
                    }
                },
                point: {
                    lat: 31.244604,
                    lng: 121.51606
                }
            },
            {
                point: {
                    lat: 31.246124,
                    lng: 121.51232
                }
            }
        ]

        this.options = {
            centerAndZoom: {
                lat: 31.244604,
                lng: 121.51606,
                zoom: 16
            },
            enableKeyboard: true
        }

        this.point = {
            lat: 39.920109,
            lng: 116.403705
        }

        this.navOptions = {
            anchor: ControlAnchor.BMAP_ANCHOR_TOP_RIGHT,
            type: NavigationControlType.BMAP_NAVIGATION_CONTROL_PAN
        }
    }

    public setAnimation(marker: BMarker): void {
        marker.setAnimation(Animation.BMAP_ANIMATION_BOUNCE)
    }

    public showWindow({ marker, map }: { marker: BMarker; map: BMapInstance }, data): void {
        console.log(data);
        map.openInfoWindow(
            new window.BMap.InfoWindow(`${data.info.content}`, {
                offset: new window.BMap.Size(0, -30),
                title: `${data.info.title}`
            }),
            marker.getPosition()
        )
    }
}
