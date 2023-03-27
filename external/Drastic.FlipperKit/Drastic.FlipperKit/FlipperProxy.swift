//
//  FlipperProxy.swift
//  Drastic.FlipperKit
//
//  Created by ミラー・ティモシー on 2023/03/27.
//

import Foundation
import FlipperKit


@objc(FlipperProxy)
public class FlipperProxy : NSObject {
    @objc
       public static let shared = FlipperProxy()
       
       @objc
       public func initializeProxy() {
           let  client = FlipperClient.shared()
           let  layoutDescriptorMapper = SKDescriptorMapper(defaults: ())
                FlipperKitLayoutComponentKitSupport.setUpWith(layoutDescriptorMapper)
           
            client?.add(FlipperKitLayoutPlugin(rootNode: UIApplication.shared, with: layoutDescriptorMapper!))
                client?.start()
       }
}
